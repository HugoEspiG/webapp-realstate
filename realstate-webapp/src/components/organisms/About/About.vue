<template>
    <div class="container justufy-content-center">
        <div class="row justify-content-center">
            <div class="col-lg-8 order-lg-1">
                <PItem variant="fs-1" class="mt-5">
                    Valores de Nuestra Empresa
                </PItem>
                <ul class="list-group list-group-numbered">
                    <li class="list-group-item">
                        <strong>Pasión por el Cliente:</strong> Nuestros clientes son nuestra razón de ser. Nos esforzamos
                        por comprender sus necesidades y deseos únicos, superando expectativas para brindarles un servicio
                        inmobiliario excepcional y personalizado.
                    </li>
                    <li class="list-group-item">
                        <strong>Innovación Continua:</strong> Abrazamos el cambio y la evolución. Buscamos constantemente
                        nuevas formas de mejorar nuestros servicios y procesos, utilizando la tecnología y la creatividad
                        para ofrecer soluciones vanguardistas en el mercado inmobiliario.
                    </li>
                    <li class="list-group-item">
                        <strong>Ética y Transparencia:</strong> Actuamos con integridad en todo momento. Mantenemos altos
                        estándares éticos en nuestras interacciones con clientes, colegas y socios. La transparencia es
                        fundamental en cada transacción que realizamos.
                    </li>
                    <li class="list-group-item">
                        <strong>Excelencia Profesional:</strong> Nos esforzamos por la excelencia en todo lo que hacemos.
                        Nuestro equipo está compuesto por profesionales capacitados y apasionados que buscan la perfección
                        en cada detalle, garantizando la calidad en cada servicio que ofrecemos.
                    </li>
                    <li class="list-group-item">
                        <strong>Adaptabilidad y Agilidad:</strong> Estamos preparados para enfrentar desafíos y cambios
                        rápidos en el mercado. Nuestra agilidad nos permite adaptarnos a las necesidades cambiantes de
                        nuestros clientes y a las tendencias del sector inmobiliario.
                    </li>
                    <li class="list-group-item">
                        <strong>Empatía y Respeto:</strong> Valoramos a las personas en todas sus diversidades. Practicamos
                        la empatía y el respeto en todas nuestras interacciones, cultivando relaciones genuinas y duraderas
                        con nuestros clientes y colegas.
                    </li>
                </ul>
            </div>
            <div class="col-lg-4 order-lg-2 text-center">
                <img src={img1} alt="Logo" class="img-fluid mt-4" />
            </div>
            <div class="col-lg-8 order-lg-2">
                <PItem variant="fs-1" class="mt-5">
                    Valores de Nuestro Equipo
                </PItem>
                <ul class="list-group list-group-numbered">
                    <li class="list-group-item">
                        <strong>Colaboración en Equipo:</strong> Creemos en el poder de la colaboración.
                        Fomentamos un entorno en el que cada miembro del equipo aporta sus fortalezas individuales para
                        lograr objetivos comunes. Juntos, alcanzamos
                        resultados excepcionales.
                    </li>
                    <li class="list-group-item">
                        <strong>Ética y Transparencia:</strong> Actuamos con integridad en todo momento.
                        Mantenemos altos estándares éticos en nuestras interacciones con clientes, colegas y socios. La
                        transparencia es fundamental en cada transacción que realizamos.
                    </li>
                    <li class="list-group-item">
                        <strong>Excelencia Profesional:</strong> Nos esforzamos por la excelencia en todo lo que
                        hacemos. Nuestro equipo está compuesto por profesionales capacitados y apasionados que buscan la
                        perfección en cada detalle, garantizando la calidad en cada servicio que ofrecemos.
                    </li>
                </ul>
            </div>
            <div class="col-lg-4 order-lg-1 text-center">
                <img src={img1} alt="Logo" class="img-fluid mt-4" />
            </div>
            <div class="col-lg-10 text-center">
                <PItem variant="fs-2" class="mt-5">
                    Misión de Nuestra Empresa
                </PItem>
                <PItem variant="fs-5" class="mt-2">
                    En nuestra empresa, nuestra misión es transformar al proceso de adquisición de vivienda en una
                    experiencia emocionante y sin complicaciones para nuestros clientes. A través de nuestra pasión por el
                    servicio al cliente, la innovación constante y los valores sólidos, nos comprometemos a ofrecer
                    soluciones inmobiliarias excepcionales que cumplan con las necesidades y deseos únicos de cada individuo
                    y familia.
                </PItem>
                <PItem variant="fs-5" class="mt-2">
                    Buscamos no solo ser líderes en el mercado inmobiliario, sino también ser reconocidos por nuestra
                    ética, transparencia y compromiso con la excelencia.
                </PItem>
                <PItem variant="fs-5" class="mt-2">
                    Nuestra misión es guiar a nuestros clientes a través del proceso de encontrar su hogar ideal, brindando
                    apoyo, asesoramiento y opciones personalizadas en cada paso del camino. Estamos aquí para hacer realidad
                    los sueños de vivienda de nuestros clientes y contribuir a su felicidad y bienestar general.
                </PItem>
            </div>
        </div>
    </div>
</template>

<script>
import PItem from '../../atoms/PItem/PItem.vue';
import Button from '../../atoms/Button/Button.vue';

export default {
    name: 'About',
    components: {
        PItem,
        Button,
    },
    methods: {
        getImageUrl(name) {
            return new URL(`${name}`, import.meta.url).href
        }
    },
    data() {
        return {
            Items: [
            ],
        }
    }
}

</script>

<style scoped></style>